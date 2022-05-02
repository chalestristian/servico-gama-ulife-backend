using servico_gama_ulife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servico_gama_ulife.Repository.Interface
{
    public interface ITokenLogRepository
    {
        TokenLogModel InsertToken(TokenLogModel userAuth);
        void InvalidToken(int userID);
        TokenLogModel GetUserByToken(string token);
    }
}
