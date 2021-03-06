USE [AvtoK]
GO
/****** Object:  Trigger [dbo].[AvtoSumma]    Script Date: 03/17/2014 09:54:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[AvtoSumma] on [dbo].[Zakazi]
for insert,update
as
declare 
	@idz int,
	@idm int
set @idz = (select ID_zakaza from inserted)
set @idm = (select ID_materiala from inserted)
update zakazi 
set stoimost = kolichestvo*(
	select cena
	from Materialy m
	where @idm=m.ID_materiala)
where ID_zakaza=@idz
