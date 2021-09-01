#include <Wire.h>


void Init_PV3109K() {
  delay(500);
  Send_I2C(0x32, 0x03, 0x00);
  Send_I2C(0x32, 0x37, 0x01);
}

void Send_I2C(byte addr, byte reg, byte val) {
  Wire.begin(Arduino_Address);   // join i2c bus (address optional for master)
  Wire.beginTransmission(addr);  // transmit to device
  Wire.write(reg);
  Wire.write(val);
  Wire.endTransmission();  // stop transmitting
  delay(10);
}

void FixShowHexValue(byte bval) {
  String sval = String(bval, HEX);
  if (bval < 0x10)
    sval = "0" + sval;
  sval.toUpperCase();
  Serial.print(sval + " ");
}

bool showt = false;
unsigned long myTime;
void Send_I2C_Page(byte addr, byte reg, byte val[] , int valSize) {

  if (showPrint == 1)  {
    String sreg = String(reg, HEX);
    if (reg < 0x10)
      sreg = "0" + sreg;
    Serial.print( "Send_I2C_Page : Reg = " + sreg + ", ");

    for (int i = 0 ; i < valSize ; i++) {
      FixShowHexValue(val[i]);
    }
    Serial.print("\r\n");
  }

  if (showt) {
    myTime = millis();
  }
  Wire.begin(Arduino_Address);   // join i2c bus (address optional for master)
  Wire.beginTransmission(addr);  // transmit to device
  Wire.write(reg);
  for (int i = 0 ; i < valSize ; i++) {
    Wire.write(val[i]);
  }
  Wire.endTransmission();  // stop transmitting

  if (showt) {
    myTime = millis() - myTime;
    Serial.print( "Spend Time : " + String( myTime) );
    Serial.print("\r\n");
    showt = false;
  }
  delay(10);
}

void Send_I2C_Block(byte addr, byte reg, byte val[] , int valSize) {

  int DataPage = 16;
  int ThisBlockSize = valSize;
  int DataPageSize = 0;
  if (showPrint == 1)  {
    Serial.print( "                          00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n");
  }

  for (int i = 0 ; i < ThisBlockSize ; i += DataPage) {

    ( (i + DataPage) <= ThisBlockSize ) ? DataPageSize = DataPage : DataPageSize = ThisBlockSize - i ;

    byte PageData[DataPageSize];

    for (int j = 0; j < sizeof(PageData) ; j++) {
      PageData[ j ] = val[ i + j ];
    }

    Send_I2C_Page(addr, reg, PageData , DataPageSize );
    reg += 0x10;

    //delay(10);
  }

}



void Write_24LC16B_EEPROM() {

  int BlockSize = 256;
  int allSize = sizeof(BinFile);
  byte EEPROM_Addr = 0x50;
  int DataBlockSize = 0;

  crc.reset();
  Write_ChkSum = 0;

  if (showPrint == 1)  {
    Serial.print("allSize = " + String(allSize) + "\r\n");
  }

  for (int i = 0 ; i < allSize ; i += BlockSize) {

    ( (i + BlockSize) < allSize ) ? DataBlockSize = BlockSize : DataBlockSize = allSize - i ;

    byte BlockData[DataBlockSize];
    if (showPrint == 1)  {
      Serial.print("EEPROM_Addr= 0x" + String(EEPROM_Addr, HEX) + ", "
                   + "i = 0x" + String(i, HEX) + ", "
                   + "BlockSize = 0x" + String(DataBlockSize, HEX) + ", ");
    }

    for (int j = 0; j < sizeof(BlockData) ; j++) {
      BlockData[j] = pgm_read_byte_near(BinFile + (i + j));
      crc.update(BlockData[j]);
    }
   
    if (showPrint == 1)  {
      Serial.print("BlockData = 0x" + String(sizeof(BlockData), HEX) + "\r\n");
      Serial.print("\r\n (R) CRC32 = " + String(crc.finalize(), HEX) + "\r\n");
    }

    Send_I2C_Block(EEPROM_Addr, 0x00, BlockData , sizeof(BlockData) );

    EEPROM_Addr++;

  }

  Write_ChkSum = crc.finalize();
  crc.reset();
}
