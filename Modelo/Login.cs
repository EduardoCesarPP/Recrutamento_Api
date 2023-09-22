using RecrutamentoApi.Extensions;

namespace RecrutamentoApi.Modelo
{
    public class Login
    {
        public string TextoTipoAcesso { get; private set; }
        public virtual TipoAcesso TipoAcesso
        {
            get { return TextoTipoAcesso.ParaTipoAcesso(); }
            set { TextoTipoAcesso = value.ParaString(); }
        }
        public int Id { get; set; }

        public Login()
        {

        }

        public Login(TipoAcesso tipoAcesso, int id)
        {
            TipoAcesso = tipoAcesso;
            Id = id;
        }
    }
}
