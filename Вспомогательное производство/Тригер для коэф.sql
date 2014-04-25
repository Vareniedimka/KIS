USE [OP]
GO
/****** Object:  Trigger [dbo].[InsGR]    Script Date: 04/25/2014 22:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[InsGR]
ON [dbo].[Grafic_rabot]
After Insert
As
BEGIN
Update Grafic_rabot
Set Raschetn_koef =
(Select Time_schtuchn
From Marsrut_karta mk
Where mk.Invertatniy_nomer = Grafic_rabot.Invertatniy_nomer) *
(Select Kolichestvo
From Polnay_primen pr
Where pr.ID = Grafic_rabot.ID)
END
