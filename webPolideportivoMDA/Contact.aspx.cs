using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webPolideportivoMDA
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Resultados.Visible = false;
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            bool todoOK = false;
            if(Nombre.Text.Equals("Nombre *"))
            {
                Resultados.Visible = true;
                Resultados.Text = "Debes intoducir un nombre";
            }
            else
            {
                if (Email.Text.Equals("Email *"))
                {
                    Resultados.Visible = true;
                    Resultados.Text = "Debes intoducir un email";
                }

                else
                {
                    if (Mensaje.Text.Equals("Mensaje *"))
                    {
                        Resultados.Visible = true;
                        Resultados.Text = "Debes intoducir un mensaje";
                    }
                    else
                    {
                        if (CheckBox1.Checked)
                        {
                            todoOK = true;
                        }

                        else
                        {
                            Resultados.Visible = true;
                            Resultados.Text = "Debes aceptar los términos de Privacidad";
                        }
                    }
                }
            }

            if (todoOK)
            {
                Resultados.Visible = true;
                Resultados.ForeColor = Color.Green;
                Resultados.Text = "Has enviado tu mensaje";
            }
        }
    }
}