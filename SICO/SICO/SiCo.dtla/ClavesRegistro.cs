using System;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;

namespace SiCo.dtla
{
    public class ClavesRegistro
    {
        private readonly RegistryKey _RegistryKey;

        public ClavesRegistro()
        {
            _RegistryKey = Registry.LocalMachine.OpenSubKey("Software\\SicoSW",
                                                            RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (_RegistryKey == null)
            {
                RegistryKey T = Registry.LocalMachine.CreateSubKey("Software\\SicoSW",
                                                                   RegistryKeyPermissionCheck.ReadWriteSubTree);
                _RegistryKey = T;
                _RegistryKey.SetValue("Instl", AppDomain.CurrentDomain.BaseDirectory);
            }
            else
            {
                var c = new Computer();
                if (! c.FileSystem.DirectoryExists(Instalacion) || Instalacion != AppDomain.CurrentDomain.BaseDirectory)
                {
                    Instalacion = AppDomain.CurrentDomain.BaseDirectory;
                }
            }
        }

        public string Instalacion
        {
            get { return _RegistryKey.GetValue("Instl", "").ToString(); }
            set { _RegistryKey.SetValue("Instl", value); }
        }
    }
}