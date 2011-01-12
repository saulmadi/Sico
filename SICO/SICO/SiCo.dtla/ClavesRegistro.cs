﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace SiCo.dtla
{
    public class ClavesRegistro
    {
        private RegistryKey _RegistryKey; 
        public ClavesRegistro()
        {
            _RegistryKey = Registry.LocalMachine.OpenSubKey("Software\\SicoSW", RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (_RegistryKey == null)
            {
                RegistryKey T = Registry.LocalMachine.CreateSubKey("Software\\SicoSW", RegistryKeyPermissionCheck.ReadWriteSubTree);
                _RegistryKey = T;
                _RegistryKey.SetValue("Instl", System.AppDomain.CurrentDomain.BaseDirectory);
            }
            else 
            {
                Microsoft.VisualBasic.Devices.Computer c = new Computer() ;
                if (! c.FileSystem.DirectoryExists(this.Instalacion) || this.Instalacion != AppDomain.CurrentDomain.BaseDirectory )
                {
                    this.Instalacion = System.AppDomain.CurrentDomain.BaseDirectory;
 
                }
   
            }
            
 
        }
    
        public string Instalacion
        {
            get
            {
                
                return  _RegistryKey.GetValue("Instl","").ToString ()    ;
                
            }
            set
            {
                _RegistryKey.SetValue("Instl", value); 
            }
        }
    }
}
