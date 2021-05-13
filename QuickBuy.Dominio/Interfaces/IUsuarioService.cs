using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Interfaces
{
    public interface IUsuarioService
    {
        Usuario GetUsuario(int id);
    }
}
