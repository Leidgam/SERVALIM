using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Modelo
{
    public class Departamento
    {
        String idDepartamento;

        public String IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        Pais pais;

        public Pais Pais
        {
            get { return pais; }
            set { pais = value; }
        }
    }
}
