Create trigger AddId
On Grafic_rabot
After Insert
As
Begin
Update Grafic_rabot
Set ID = 
(Select ID_marshrut
From Marsrut_karta mk
Where mk.Invertatniy_nomer = Grafic_rabot.Invertatniy_nomer)
END
Go