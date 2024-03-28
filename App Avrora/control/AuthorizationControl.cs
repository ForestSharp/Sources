using App_Avrora.model;

namespace App_Avrora.control
{
    internal class AuthorizationControl
    {
        private ServerSQL serverSQL;

        public ServerSQL ServerSQL { get => serverSQL; set => serverSQL = value; }

        internal AuthorizationControl()
        {
            ServerSQL = new();
        }

    }
}
