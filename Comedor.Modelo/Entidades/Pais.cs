using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Pais
    {
        String idPais;

        public String IdPais
        {
            get { return idPais; }
            set { idPais = value; }
        }
        String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public List<Departamento> departamentos = new List<Departamento>();
    }
}
