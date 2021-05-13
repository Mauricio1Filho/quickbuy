using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio
{
    public class UsuarioService : IUsuarioService
    {
        public Usuario GetUsuario(int id)
        {
            return id.Equals(123) ? new Usuario() { Id= 123}: null;
        }
    }
}
