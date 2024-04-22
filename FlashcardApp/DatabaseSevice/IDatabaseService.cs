interface IDapperDatabaseService
{
    void DapperExecuteNonQuerySQL(string sql);
    bool DapperExecuteScalarExist(string sql);
}