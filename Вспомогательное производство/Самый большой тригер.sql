Alter trigger [dbo].[InsGR]
ON [dbo].[Grafic_rabot]
After Insert, Update
As
BEGIN
Update Grafic_rabot
Set ID = 
(Select ID_marshrut
From Marsrut_karta mk
Where mk.Invertatniy_nomer = Grafic_rabot.Invertatniy_nomer)

Update Grafic_rabot
Set Raschetn_koef =
(Select Time_schtuchn
From Marsrut_karta mk
Where mk.Invertatniy_nomer = Grafic_rabot.Invertatniy_nomer) *
(Select Kolichestvo
From Polnay_primen pr
Where pr.ID = Grafic_rabot.ID)
END