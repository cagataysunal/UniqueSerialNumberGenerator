using UniqueSerialNumberGenerator;

SerialNumberDatabaseSQLite db = new();
db.InitializeDatabase();


for (int i = 0; i < 10000000; i++)
{
    string myNumber = SerialNumberGenerator.GenerateNonConsecutiveIncreasingNorRepeating();
    bool result = db.TryInsertSerialNumber(myNumber);
    Console.WriteLine($"#{i} {myNumber}: {(result ? "Added successfully" : "Couldn't add serial number'")}");
}
