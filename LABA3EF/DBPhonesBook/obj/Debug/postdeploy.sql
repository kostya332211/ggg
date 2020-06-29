﻿/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO [dbo].[Person] ([Id], [PersonName], [PhoneNumber]) VALUES
('59b4f489-9603-4db6-a20b-823b69892cba', 'Kostya', '103'),
('59b4f489-9603-4db6-a20b-823b69892cbb', 'Vasia', '228322111'),
('59b4f489-9603-4db6-a20b-823b69892cbc', 'IIIIIIIIIIIIIIIIIIIIIIIIIIIIIgor', '7777777')
GO