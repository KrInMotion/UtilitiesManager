
/*Reset all data*/

use [UtilitiesManager]
go
delete from [Month]
delete from [BillType]
delete from [BillProvider]
go
DBCC CHECKIDENT('Month', RESEED, 0)
DBCC CHECKIDENT('BillType', RESEED, 0)
DBCC CHECKIDENT('BillProvider', RESEED, 0)
insert into [Month] ([Name]) values(N'Январь'),
	(N'Февраль'),
	(N'Март'),
	(N'Апрель'),
	(N'Май'),
	(N'Июнь'),
	(N'Июль'),
	(N'Август'),
	(N'Сентябрь'),
	(N'Октябрь'),
	(N'Ноябрь'),
	(N'Декабрь')
go
insert into [BillType] ([TypeName]) values(N'Квитанция за газ'),
	(N'Квитанция за электроэнергию')
go
insert into [BillProvider] ([ProviderName]) values(N'ОАО "Тульская энергосбытовая компания"'),
	(N'ООО "Мега-Т"'),
	(N'ОАО ОЕИРЦ')
go
