using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CTRL_Arduino
{
    public partial class Test_Arduino_Code : Form
    {
        public Test_Arduino_Code()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = !progressBar1.Visible;
            //Read_24LC16B_EEPROM();
        }

        void Read_24LC16B_EEPROM()
        {

            int BlockSize = 256;
            int allSize = 2012;
            byte EEPROM_Addr = 0x50;
            int DataBlockSize = 0;

            //  for (int i = 0 ; i < allSize ; i += BlockSize) {
            //
            //    ( (i + BlockSize) < allSize ) ? DataBlockSize = BlockSize : DataBlockSize = allSize - i ;
            //    byte BlockData[DataBlockSize];
            //  if (showPrint == 1)  {
            //      Serial.print("EEPROM_Addr= 0x" + String(EEPROM_Addr, HEX) + ", "
            //                   + "i = 0x" + String(i, HEX) + ", "
            //                   + "BlockSize = 0x" + String(DataBlockSize, HEX) + ", \r\n");
            //Serial.print( "         00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n");
            //  }
            //    //    Read_I2C_Sequential(EEPROM_Addr, 0x00);
            //    //    Read_I2C_Sequential(EEPROM_Addr, 0x00);
            //    Read_I2C_Block(EEPROM_Addr, 0x00, BlockData , sizeof(BlockData) );
            //
            //    EEPROM_Addr++;
            //
            //  }
            int fixAddr = 0;
            Console.WriteLine("00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n");

            int jdge = 0;
            int skipone = 0;

            //Read_I2C_Zero(EEPROM_Addr , 0x00);


            for (int i = 0; i <= allSize; i++)
            {

                if (fixAddr != (i / 256))
                {
                    fixAddr = (i / 256);
                    EEPROM_Addr = (byte)(EEPROM_Addr + 1);
                }
                byte block_Addr = (byte)(i % 256);
                //Read_I2C(EEPROM_Addr, block_Addr);

                //if (readOneDate != pgm_read_byte_near(BinFile + (i - 1)))
                //{
                //    Serial.print("Error in=" + String(i, HEX) + "; ");
                //    Serial.print("BinFile =" + String(pgm_read_byte_near(BinFile + (i - 1)), HEX)
                //                 + " ,readOneDate=" + String((readOneDate), HEX) + "\r\n");
                //    jdge = 1;
                //}
            }

            if (jdge == 0)
                Console.WriteLine("\r\nOK!!\r\n");



            //Read_I2C_Zero(EEPROM_Addr, 0x00);
        }

    }

}
