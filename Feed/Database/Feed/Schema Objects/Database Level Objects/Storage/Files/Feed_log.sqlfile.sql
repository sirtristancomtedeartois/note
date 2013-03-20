ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [Feed_log], FILENAME = 'D:\Data\Feed_log.ldf', SIZE = 1024 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

