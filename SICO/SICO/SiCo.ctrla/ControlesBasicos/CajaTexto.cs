using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SiCo.ctrla
{
    public partial class CajaTexto : TextBox
    {
        #region Declaraciones

        private Color _ColorError = Color.Red;
        protected string _ExpresionValidacion;
        protected string _MensajeError;
        protected Regex _Validador;
        private Color _backcolor;
        private TiposTexto _tipotexto = TiposTexto.Alfanumerico;

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

        public bool EsObligatorio { get; set; }

        public Color ColorError
        {
            get { return _ColorError; }
            set { _ColorError = value; }
        }

        public bool EnterPorTab { get; set; }

        public string ExpresionValidacion
        {
            get { return _ExpresionValidacion; }
            set
            {
                if (value != null)
                    _Validador = new Regex(value);

                _ExpresionValidacion = value;
            }
        }

        public string MensajeError
        {
            get { return _MensajeError; }
            set { _MensajeError = value; }
        }

        public TiposTexto TipoTexto
        {
            get { return _tipotexto; }
            set
            {
                switch (value)
                {
                    case TiposTexto.Alfanumerico:
                        Text = "";

                        break;
                    case TiposTexto.Parrafo:
                        Text = "";
                        Multiline = true;
                        break;
                    case TiposTexto.Entero:
                        break;
                    case TiposTexto.Decimal:
                        Text = "0.00";
                        ExpresionValidacion = "^(?!^0*$)(?!^0*\\.0*$)^\\d{1,9}(\\.\\d{1,3})?$";
                        MaxLength = 12;
                        TextAlign = HorizontalAlignment.Right;
                        break;

                    case TiposTexto.Alfabetico:

                        Text = "";
                        ExpresionValidacion = string.Empty;
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
                    return base.Text.Trim();
            }

            set { base.Text = value; }
        }

        public int? ValorInt
        {
            get
            {
                try
                {
                    Int32 d = 0;
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
                    Text = string.Empty;
                }
                else
                {
                    Text = value.ToString();
                }
            }
        }

        public long? ValorLong
        {
            get
            {
                try
                {
                    long d = 0;
                    if (Int64.TryParse(base.Text, out d))
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
                    Text = string.Empty;
                }
                else
                {
                    Text = value.ToString();
                }
            }
        }


        public Decimal ValorDecimal
        {
            get
            {
                try
                {
                    Decimal d = 0;
                    if (Decimal.TryParse(base.Text, out d))
                    {
                        return d;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
            set
            {

                {
                    Text = value.ToString();
                }
            }
        }

        #endregion

        #region Eventos

        private void CajaTexto_TextChanged(object sender, EventArgs e)
        {
            ForeColor = DefaultForeColor;
            BackColor = _backcolor;
        }

        private void CajaTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (TipoTexto)
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
                    else
                    {
                        if (Text.Contains("."))
                        {
                            string[] val = Text.Split('.');
                            if (val[1].Length == 2)
                            {
                                if (Text.IndexOf(".") < SelectionStart)
                                    e.Handled = true;
                            }
                        }
                    }

                    if (e.KeyChar == '.')
                    {
                        bool flag = false;
                        int contador = 0;
                        for (int x = 0; x < Text.Length; x++)
                        {
                            if (Text.Substring(x, 1) == ".")
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

                    if (!char.IsLetter(e.KeyChar))
                        e.Handled = true;

                    if (char.IsControl(e.KeyChar))
                        e.Handled = false;

                    if (char.IsWhiteSpace(e.KeyChar))
                        e.Handled = false;

                    break;
                default:
                    break;
            }
            if (Strings.Asc(e.KeyChar) == 13 && EnterPorTab)
            {
                e.Handled = true;
            }
        }

        private void CajaTexto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && EnterPorTab)
            {
                if (EsObligatorio)
                {
                    if (Text != string.Empty)
                        SendKeys.Send("{TAB}");
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void CajaTexto_KeyDown(object sender, KeyEventArgs e)
        {
        }

        #endregion

        #region Metodos

        protected override void OnValidated(EventArgs e)
        {
            if (!EsValido())
                ForeColor = ColorError;
            else
                ForeColor = DefaultForeColor;


            base.OnValidated(e);
        }

        private void InicializacionDelegados()
        {
            KeyDown += CajaTexto_KeyDown;
            TextChanged += CajaTexto_TextChanged;
            KeyPress += CajaTexto_KeyPress;
            KeyUp += CajaTexto_KeyUp;
            _backcolor = BackColor;
            EnterPorTab = true;
        }

        public bool EsValido()
        {
            bool flag = true;
            if (Text == string.Empty)
            {
                return true;
            }

            if (_Validador != null)
            {
                flag = _Validador.IsMatch(Text);
            }

            return flag;
        }

        public bool EsVacio()
        {
            bool flag = false;
            if (EsObligatorio)
            {
                if (Text == string.Empty)
                {
                    BackColor = ColorError;
                    flag = true;
                }
            }

            return flag;
        }

        #endregion
    }
}