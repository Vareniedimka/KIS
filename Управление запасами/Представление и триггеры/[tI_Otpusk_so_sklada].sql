USE [AvtoK]
GO
/****** Object:  Trigger [dbo].[tI_Otpusk_so_sklada]    Script Date: 03/17/2014 09:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER TRIGGER [dbo].[tI_Otpusk_so_sklada] ON [dbo].[Otpusk_so_sklada] FOR INSERT AS
/* ERwin Builtin Trigger */
/* INSERT trigger on Otpusk_so_sklada */
BEGIN
   DECLARE @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin Trigger */
  /* Materialy  Otpusk_so_sklada on child insert restrict */
  /* ERWIN_RELATION:CHECKSUM="00016001", PARENT_OWNER="", PARENT_TABLE="Materialy"
    CHILD_OWNER="", CHILD_TABLE="Otpusk_so_sklada"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_1712", FK_COLUMNS="ID_materiala" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(ID_materiala)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Materialy
        WHERE
          /* %JoinFKPK(inserted,Materialy) */
          inserted.ID_materiala = Materialy.ID_materiala
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," and") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30002,
             @errmsg = 'Cannot insert Otpusk_so_sklada because Materialy does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END

