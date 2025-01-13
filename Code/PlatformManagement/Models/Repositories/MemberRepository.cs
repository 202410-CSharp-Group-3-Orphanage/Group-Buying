using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using MT.Security.Hashing;

namespace PlatformManagement.Models.Repositories
{
    public class MemberRepository
    {
        private readonly SqlConnection _sqlConnection;
        

        public MemberRepository(SqlConnection sqlConnection)
        {
            
            _sqlConnection = sqlConnection;            
        }

        public bool VaildateAccountIsExist(string account)
        {
            const string sql = @"
            SELECT TOP 1 1
            FROM Members
            WHERE Account = @Account";

            var exists = _sqlConnection.QueryFirstOrDefault<int?>(sql, new { Account = account });

            return exists.HasValue;
        }

        public bool ValidateLoginPasswordIsCorrect(string account, string password)
        {
            const string sql = @"
            SELECT EncryptedPassword
            FROM Members
            WHERE Account = @Account";

            var encryptedPassword = _sqlConnection.QueryFirstOrDefault<string>(sql, new { Account = account });

            if (encryptedPassword == null)
                return false;

            return Sha256Hasher.Verify(password, encryptedPassword);
        }
    }
}
