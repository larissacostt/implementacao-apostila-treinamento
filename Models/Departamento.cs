using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace capitulo01.Models
{
    public class Departamento
    {
        public long? DepartamentoID {  get; set; }
        public string? Nome {  get; set; }

        public long? InstituicaoID {  get; set; }
        public Instituicao Instituicao { get; set; }
    }
}
