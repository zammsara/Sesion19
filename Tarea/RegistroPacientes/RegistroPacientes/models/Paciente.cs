using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPacientes.models
{
    public struct Paciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string DepartamentoMed { get; set; }
        public bool SiAlergias { get; set; }
        public bool NoAlergias { get; set; }
        public string Alergias { get; set; }

    }
}
