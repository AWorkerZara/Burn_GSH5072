#include <Wire.h>

int acont = -1;
byte readOneDate;
void Read_I2C(byte addr, byte reg) {
  acont++;
  Wire.begin(Arduino_Address);  // join i2c bus (address optional for master)
  Wire.beginTransmission(addr);   // transmit to device
  Wire.write(reg);
  Wire.requestFrom(addr, 16);  // request 6 bytes from slave device #8

  while (Wire.available()) { // slave may send less than requested
    readOneDate = Wire.read();  // receive a byte as character
    if (showPrint == 1)  {
      String sreg = String(readOneDate, HEX);
      if (readOneDate < 0x10)
        sreg = "0" + sreg;
      sreg.toUpperCase();

      if (acont > 15) {
        Serial.print("\n");      // print the character
        acont = 0;
      }
      Serial.print( sreg  + " ");
    }
    Wire.endTransmission();  // stop transmitting
    delay(1);
  }
}

void Read_I2C_Sequential(byte addr, byte reg , int chk) {
  byte ReadByteData[16];
  int bcount = 0;
  Wire.begin(Arduino_Address);  // join i2c bus (address optional for master)
  Wire.beginTransmission(addr);   // transmit to device
  Wire.write(reg);
  Wire.requestFrom(addr, 16);  // request 6 bytes from slave device #8
  while (Wire.available())  // slave may send less than requested
  {
    ReadByteData[bcount] = Wire.read();  // receive a byte as character
    bcount++;
  }
  Wire.endTransmission();  // stop transmitting

  if (chk == 1) {
    if (showPrint == 1)  {
      String sreg = String(reg, HEX);
      if (reg < 0x10)
        sreg = "0" + sreg;
      Serial.print( "Reg=0x" +  sreg  + " ");

      for (int i = 0 ; i < sizeof(ReadByteData) ; i++) {
        FixShowHexValue(ReadByteData[i]);
      }
      Serial.print("\r\n");
    }

    /*
        Check Bin File data
    */
    int binAddrStart = (addr - 0x50) * 256 + reg;
    int binAddrCount = (binAddrStart + 16) > sizeof(BinFile) ? sizeof(BinFile) - binAddrStart : 16;
    for (int i = 0; i < binAddrCount ; i++) {
      crc.update(ReadByteData[i]);
//      if (ReadByteData[i] !=  pgm_read_byte_near(BinFile + (binAddrStart + i ))) {
//        Serial.print("Error on Addr=" + String((binAddrStart + i ), HEX) + "\r\n");
//      }
    }
  }
  delay(10);
}

void Read_I2C_Block(byte addr, byte reg, byte val[] , int valSize) {

  int DataPage = 16;
  int ThisBlockSize = valSize;
  int DataPageSize = 0;
  Read_I2C(addr, reg);
  for (int i = 0 ; i < ThisBlockSize ; i += DataPage) {
    ( (i + DataPage) <= ThisBlockSize ) ? DataPageSize = DataPage : DataPageSize = ThisBlockSize - i ;

    Read_I2C_Sequential(addr, reg , 0);
    Read_I2C_Sequential(addr, reg , 1);
    reg += 0x10;
    if (reg >= 0x100)
      reg = 0x00;

    //delay(10);
  }


}

void Read_24LC16B_EEPROM() {
  //Wire.setWireTimeout(1000000 /* us */, true /* reset_on_timeout */);
  //Wire.setWireTimeout();
  int BlockSize = 256;
  int allSize = sizeof(BinFile);
  byte EEPROM_Addr = 0x50;
  int DataBlockSize = 0;
  crc.reset();
  Read_ChkSum = 0;
  
  //allSize = 4095;
  
  if (showPrint == 1)  {
    Serial.print("allSize = " + String(allSize, HEX) + "\r\n");
  }
  for (int i = 0 ; i < allSize ; i += BlockSize) {

    ( (i + BlockSize) < allSize ) ? DataBlockSize = BlockSize : DataBlockSize = allSize - i ;
    byte BlockData[DataBlockSize];
    if (showPrint == 1)  {
      Serial.print("EEPROM_Addr= 0x" + String(EEPROM_Addr, HEX) + ", "
                   + "i = 0x" + String(i, HEX) + ", "
                   + "BlockSize = 0x" + String(DataBlockSize, HEX) + ", \r\n");
      Serial.print( "         00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n");
      //Serial.print("\r\n (W) CRC32 = " + String(crc.finalize(), HEX) + "\r\n");
    }

    Read_I2C_Block(EEPROM_Addr, 0x00, BlockData , sizeof(BlockData) );
    EEPROM_Addr++;
  }

  Read_ChkSum = crc.finalize();
  crc.reset();

  //  int fixAddr = 0;
  //  Serial.print( "00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n");
  //
  //  int jdge = 0;
  //  int skipone = 0;

  //Read_I2C_Zero(EEPROM_Addr , 0x00);
  //    for (int i = 0 ; i <= allSize ; i++) {
  //
  //      if (fixAddr != (i / 256)) {
  //        fixAddr = (i / 256);
  //        EEPROM_Addr = EEPROM_Addr + 1;
  //      }
  //      byte block_Addr = (i % 256);
  //      Read_I2C(EEPROM_Addr, block_Addr);
  //
  //      if (readOneDate != pgm_read_byte_near(BinFile + (i - 1)))    {
  //        Serial.print("Error in=" + String(i , HEX) + "; ");
  //        Serial.print("BinFile =" + String(pgm_read_byte_near(BinFile + (i - 1)) , HEX)
  //                     + " ,readOneDate=" + String((readOneDate) , HEX) + "\r\n");
  //        jdge = 1;
  //      }
  //    }
  //
  //    if (jdge == 0)
  //      Serial.print("\r\nOK!!\r\n");

  //Read_I2C(EEPROM_Addr , 0x00);
}


void Chk_Now_Ver()
{
  crc.reset();
  Fixture_ChkSum = 0;
  for (int i = 0 ; i < sizeof(BinFile) ; i++)
    crc.update(pgm_read_byte_near(BinFile+i));
  Fixture_ChkSum = crc.finalize();
  crc.reset();
}
