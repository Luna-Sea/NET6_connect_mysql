数据结构如下:

+--------------------+
| Database           |
+--------------------+
| animals            |
| information_schema |
| mysql              |
| performance_schema |
| sys                |
+--------------------+

+-------------------+
| Tables_in_animals |
+-------------------+
| cat               |
+-------------------+

+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  |     | NULL    |       |
| name  | varchar(10) | YES  |     | NULL    |       |
| eyes  | int         | YES  |     | NULL    |       |
| foots | int         | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+

+------+-----------+------+-------+
| id   | name      | eyes | foots |
+------+-----------+------+-------+
|    0 | tom       |    2 |     4 |
|    1 | buki      |    2 |     2 |
|    2 | lightting |    2 |     8 |
+------+-----------+------+-------+


0.在mysql中创建一个账户guofu
CREATE USER 'your_username'@'localhost' IDENTIFIED BY 'your_password';

GRANT ALL PRIVILEGES ON your_database.* TO 'your_username'@'localhost';
//分配animals的权限给它,需将" your_database" 修改为实际数据库animals;
FLUSH PRIVILEGES;
//刷新权限
-------------
1.安装ADO.net驱动
sudo apt-get install libmysqlclient-dev
--------------------
2.导入库
dotnet add package MySql.Data
----------------
3.
string connectionString = "Server=localhost;Port=3306;Database=animals;Uid=your_username;Pwd=your_password;";
//								        第0步创建的your_username账户,密码为your_password
MySqlConnection connection = new MySqlConnection(connectionString);
connection.Open();

string query = "SELECT * FROM cat(表格名称)";
//命令内容
MySqlCommand command = new MySqlCommand(query, connection);
//初始化查询器
                using (MySqlDataReader reader = command.ExecuteReader())
				       //启动查询,获取返回结果
                {
                    while (reader.Read())
                    {
                        // 处理查询结果
                        int id = reader.GetInt32("id");
                        string name = reader.GetString("name");
                        Console.WriteLine($"ID: {id}, Name: {name}");
                    }
                }

------------查询结果------------
ID: 0, Name: tom
ID: 1, Name: buki
ID: 2, Name: lightting
-------------------------------
