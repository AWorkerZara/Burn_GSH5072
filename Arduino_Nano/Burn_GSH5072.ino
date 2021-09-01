#include <Wire.h>
#include <avr/wdt.h>
#include <CRC32.h>

//// Address fix : Dothinkey catch address = 0xF0 ,
//// in arduino need set 0x78 (0xF0 >> 1)

//// GSH5072 power on until Statable need 60~70ms.
/*
   SDA => analog pin 4
   SCL => analog pin 5
*/

void Write_24LC16B_EEPROM();
void Read_24LC16B_EEPROM();
void Init_PV3109K();
void Catch_Open_Camera_Button();

int ledPin = 13;      // select the pin for the LED
int Arduino_Address = 196;
int showPrint = 0 ;
int V_Action = HIGH;
int V_Done = LOW;

CRC32 crc;
uint32_t  Write_ChkSum ;
uint32_t  Read_ChkSum ;

void setup() {
  int ledPin = 13;      // select the pin for the LED
  pinMode(ledPin, OUTPUT);
  //Wire.setClock(400000);
  Serial.setTimeout(50);
  Serial.begin(9600);           //  setup serial
  Serial.print("Start Wating Burn Command:\r\n");
  digitalWrite(ledPin, V_Done);
  pinMode(2, INPUT);           // set pin to input

}

void Read_Voltage() {
  ////  read the value from the sensor:
  delay(150);
  int sensorValue_1 = analogRead(A6);
  int sensorValue_2 = analogRead(A7);
  Serial.print(String(sensorValue_1) + "," + String(sensorValue_2));
  wdt_reset();
  wdt_disable();
  //digitalWrite(ledPin, V_Done);
}

void loop() {

  String inMsg = "";
  if (Serial.available()) {
    inMsg = Serial.readString();
    //wdt_reset();
    wdt_enable(WDTO_8S);
  }
  int inMsgLength = inMsg.length();
  inMsg.trim();
  if (inMsg == "Burn") {
    digitalWrite(ledPin, V_Action);
    delay(150);
    Write_24LC16B_EEPROM();
    Init_PV3109K();
    
  }
  else if (inMsg == "BurnChk") {
    digitalWrite(ledPin, V_Action);
    delay(150);
    Write_24LC16B_EEPROM();
    delay(200);
    Read_24LC16B_EEPROM();

    if (Write_ChkSum != Read_ChkSum)
      Serial.print("Error on CheckSum !!\r\n");

    Init_PV3109K();
  }
  else if (inMsg == "DbgMode") {
    unsigned long StartBurnTime, StartCheckTime;
    unsigned long Tmp1;
    digitalWrite(ledPin, V_Action);
    Serial.print("Start Burn...\r\n");
    Tmp1 = millis();
    delay(150);
    //Write_24LC16B_EEPROM();
    StartBurnTime = millis() - Tmp1;
    delay(200);
    Serial.print("Start Check...\r\n");
    Tmp1 = millis();
    Read_24LC16B_EEPROM();
    StartCheckTime = millis() - Tmp1;
    Serial.println("Check Done!!");
    Serial.println(" Burn Time = " + String(StartBurnTime) + " ms");
    Serial.println("Check Time = " + String(StartCheckTime) + " ms");
    Serial.println("Total Time = " + String(StartBurnTime + StartCheckTime) + " ms");

    if (Write_ChkSum != Read_ChkSum)
      Serial.print("Error on CheckSum !!\r\n");
      
    Init_PV3109K();
  }
  else if (inMsg == "OCam") {
    digitalWrite(ledPin, V_Action);
    wdt_disable();
    //Serial.print("\r\nOpen Camera\r\n");
  }
  else if (inMsg == "CCam") {
    digitalWrite(ledPin, V_Done);
    wdt_disable();
    //Serial.print("\r\nClose Camera\r\n");
  }
  if (inMsgLength != 0) {
    if ( (inMsg == "OCam") || (inMsg == "CCam") ) {
      //Serial.print("\r\nNo Read Voltage\r\n");
    }
    else {
      Read_Voltage();
    }
  }



}
