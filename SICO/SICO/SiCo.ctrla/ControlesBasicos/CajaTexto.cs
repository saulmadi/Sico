using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic;

namespace SiCo.ctrla
{
    
    public partial class CajaTexto : TextBox
    {
        #region Declaraciones

        private Color _ColorError = Color.Red;
        private bool _EsObligatorio = false;
        protected Regex _Validador;
        protected string _ExpresionValidacion;
        protected string _MensajeError;
        private TiposTexto _tipotexto= TiposTexto.Alfanumerico;
        private Color _backcolor;
        #endregion

        #region Construtores

        public CajaTexto()
        {
            InitializeComponent();
            InicializacionDelegados();
         
        }

        public CajaTexto(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InicializacionDelegados();
         
        }


        #endregion

        #region Propiedades

        public bool EsObligatorio
        {
            get { return _EsObligatorio; }
            set { _EsObligatorio = value; }
        }

        public System.Drawing.Color ColorError
        {
            get
            {
                return _ColorError;
            }
            set
            {
                _ColorError = value;
            }
        }

        public bool EnterPorTab
        {
            get;
            set;
        }

        public string ExpresionValidacion
        {
             get
            {
                return _ExpresionValidacion;
            }
             set
            {
                if (value != null)
                    _Validador = new Regex(value);

                _ExpresionValidacion = value;
            }
        }

        public string MensajeError
        {
            get
            {
                return _MensajeError;
            }
            set
            {
                _MensajeError = value;
            }
        }

        public TiposTexto TipoTexto
        {
            get 
            {
                return _tipotexto;
            }
            set
            {
                switch (value )
                {
                    case TiposTexto.Alfanumerico:
                        this.Text = "";                       
                       
                        break;
                    case TiposTexto.Parrafo:
                        this.Text = "";
                        this.Multiline = true;                      
                        break;
                    case TiposTexto.Entero:                                                             
                               break;
                    case TiposTexto.Decimal:
                        this.Text = "0.00";
                        this.ExpresionValidacion = "^(?!^0*$)(?!^0*\\.0*$)^\\d{1,9}(\\.\\d{1,3})?$";
                        this.MaxLength = 12; 
                        this.TextAlign=HorizontalAlignment.Right;
                        break;

                    case TiposTexto.Alfabetico:
                        
                        this.Text = "";
                        this.ExpresionValidacion = string.Empty;
                        break;
                    default:
                        break;
                }  
                
                _tipotexto = value;
            }
                
        }

        public string Texto
        {
            get
            {
                if (base.Text == string.Empty)
                    return null;
                else
                    return base.Text.Trim() ;
            }

            set { base.Text = value; }
        }       

        public int? ValorInt
        {
            get
            {
                try
                {
                    Int32 d=0;
                    if (Int32.TryParse(base.Text, out d))
                    {
                        return d;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch 
                {
                    return null;
                    
                } 
            }
            set
            {
                if (value == null)
                {
                    this.Text = string.Empty;
                }
                else
                {
                    this.Text = value.ToString();
                }
            }
        }

        public 

        #endregion        

        #region Eventos
        void CajaTexto_TextChanged(object sender, EventArgs e)
        {
            this.ForeColor = DefaultForeColor;
            this.BackColor=_backcolor ;

        }

        void CajaTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (TipoTexto )
            {
                case TiposTexto.Alfanumerico:
                    
                    break;

                case TiposTexto.Parrafo:
                    break;

                case TiposTexto.Entero:
                    if (!char.IsNumber(e.KeyChar))
                        e.Handled = true;
                       

                    if (char.IsControl(e.KeyChar))
                        e.Handled = false;
                    break;

                case TiposTexto.Decimal:

                    if (!char.IsNumber(e.KeyChar))
                        e.Handled = true;
                    
                    if (e.KeyChar == '.')
                    {
                        bool flag = false  ;
                        int contador=0;
                        for (int x = 0; x < this.Text.Length; x++)
                        {
                            if (Text.Substring(x, 1)== ".")
                                contador++; 
                        }
                        if (contador >= 1)
                            flag = true;

                        e.Handled = flag; 
                    }

                    if (char.IsControl(e.KeyChar))
                        e.Handled = false;

                    break;

                case TiposTexto.Alfabetico:
                    
                    if( !char.IsLetter(e.KeyChar))
                        e.Handled=true ;

                    if (char.IsControl(e.KeyChar))
                        e.Handled = false;

                    if (char.IsWhiteSpace(e.KeyChar))
                        e.Handled = false; 

                    break;
                default:
                    break;

                  
            }
            if (Microsoft.VisualBasic.Strings.Asc(e.KeyChar) == 13 && this.EnterPorTab)
            {
                e.Handled = true; 
            }
            

        }

        void CajaTexto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && this.EnterPorTab )
            {
                if (this.EsObligatorio)
                {
                    if (this.Text != string.Empty)
                        SendKeys.Send("{TAB}");
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }               
            }
        }

        void CajaTexto_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        #endregion

        #region Metodos

        protected override void OnValidated(System.EventArgs e)
        {
            if (!this.EsValido())
                this.ForeColor = ColorError;
            else
                this.ForeColor = DefaultForeColor;


            base.OnValidated(e);
        }

        private void  InicializacionDelegados()
        {
            this.KeyDown += new KeyEventHandler(CajaTexto_KeyDown);
            this.TextChanged += new EventHandler(CajaTexto_TextChanged);
            this.KeyPress += new KeyPressEventHandler(CajaTexto_KeyPress);
            this.KeyUp += new KeyEventHandler(CajaTexto_KeyUp); 
            _backcolor = this.BackColor;
            this.EnterPorTab = true;
        }

            

        public bool EsValido()
        {
            
                bool flag = true;
                
                if (_Validador != null)
                {
                    flag = _Validador.IsMatch(this.Text);
                }
               
                return flag;
            
        }
        
        public bool EsVacio()
        {           
                bool flag = false ;
                if (EsObligatorio)
                {
                    if (this.Text == string.Empty)
                    {
                        this.BackColor = this.ColorError;
                        flag = true;
                    }
                }

                return flag;
            
        }
        

        #endregion
       
    }
}
