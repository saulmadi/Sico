using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;


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

        public bool EsValido
        {
            get
            {
                bool flag = true;
                
                if (_Validador != null)
                {
                    flag = _Validador.IsMatch(this.Text);
                }
                if (EsObligatorio)
                {
                    if (this.Text == string.Empty)
                        flag = false;
                }

                return flag;
            }
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
                        this.MaxLength = 255;
                       
                        break;
                    case TiposTexto.Parrafo:
                        this.Text = "";
                        this.Multiline = true;                      
                        break;
                    case TiposTexto.Entero:
                        this.MaxLength = 12; 
                        this.Text = "0";                       
                        this.TextAlign = HorizontalAlignment.Right;
                        break;
                    case TiposTexto.Decimal:
                        this.Text = "0.00";
                        this.ExpresionValidacion = "^(?!^0*$)(?!^0*\\.0*$)^\\d{1,9}(\\.\\d{1,3})?$";
                        this.MaxLength = 12; 
                        this.TextAlign=HorizontalAlignment.Right;
                        break;

                    case TiposTexto.Alfabetico:
                        this.MaxLength = 3655;
                        this.Text = "";
                        this.ExpresionValidacion = string.Empty;
                        break;
                    default:
                        break;
                }  
                
                _tipotexto = value;
            }
                
        }

        #endregion

        public  string Texto
        {
            get
            {
                if (base.Text == string.Empty)
                    return null;
                else
                    return base.Text;
            }
            set { base.Text = value; }
        }

        #region Eventos
        void CajaTexto_TextChanged(object sender, EventArgs e)
        {

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
        }

        #endregion

        #region Metodos

        protected override void OnValidated(System.EventArgs e)
        {
            if (!this.EsValido)
                this.ForeColor = ColorError;
            else
                this.ForeColor = DefaultForeColor;


            base.OnValidated(e);
        }

        private void  InicializacionDelegados()
        {
            this.TextChanged += new EventHandler(CajaTexto_TextChanged);
            this.KeyPress += new KeyPressEventHandler(CajaTexto_KeyPress);
        }     
        

        #endregion
       
    }
}
