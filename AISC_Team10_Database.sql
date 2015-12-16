-- create database
create database AISC_Team10_Database
go
use AISC_Team10_Database
go

-- table contains basic info of an account
create table ACCOUNT
(
	Email nvarchar(50),
	Sex nvarchar(6) check(Sex in ('Male', 'Female', 'Other')),
	FullName nvarchar(30) not null,
	DoB Date, -- at least 18 years old
	UserPassword nvarchar(30), -- at least 6 chars, including capslock, normal chars and special symbols
	UserID nvarchar(30) primary key,
	UserAddress nvarchar(100),
	Phone nvarchar(15),
)

-- contains pairs DOCTOR_PATIENT, RELATIVE_PATIENT, RELATIVE_RELATIVE
create table ACCOUNT_LINK
(
	UserID_1 nvarchar(30),
	UserID_2 nvarchar(30),
	_state int, -- 0: requested, 1: already linked

	primary key(UserID_1, UserID_2)
)

create table RELATIVE_ACCOUNT
(
	UserID nvarchar(30) primary key
)

create table DOCTOR_ACCOUNT
(
	UserID nvarchar(30) primary key,
	HospitalName nvarchar(50), -- name of main hospital or clinic where he is working
	WorkAddress nvarchar(50),
	Speciality nvarchar(30) -- main major of doctor
)

create table PATIENT_ACCOUNT
(
	UserID nvarchar(30) primary key
)

create table HEALTH_HISTORY -- bệnh án
(
	UserID nvarchar(30),
	Note nvarchar(100),
	StartTime Date,
	EndTime Date,
	SickName nvarchar(30),
	SickLevel nvarchar(30)

	primary key (UserID, StartTime, SickName)
)

create table HYPERSENSITIVITY_PHARMACY
(
	UserID nvarchar(30) primary key,
	Note nvarchar(100),
	DrugName nvarchar(30)
)

create table DIAGNOSIS_RESULT
(
	UserID_Doctor nvarchar(30),
	UserID_Patient nvarchar(30),
	Symptoms nvarchar(150),
	Note nvarchar(100),
	SickLevel nvarchar(30),
	CheckingTime DateTime,
	SickName nvarchar(30),

	primary key (UserID_Doctor, CheckingTime)
)

create table PRESCRIPTION
(
	UserID_Doctor nvarchar(30),
	UserID_Patient nvarchar(30),
	Note nvarchar(100),
	SickLevel nvarchar(30),
	CreationTime DateTime,
	SickName nvarchar(30),

	primary key (UserID_Doctor, CreationTime)
)

create table PRESCRIPTION_DETAIL
(
	UserID_Doctor nvarchar(30),
	CreationTime DateTime,

	Dosage float,
	Amount float,
	DrugName nvarchar(30) unique,
	UsedTime nvarchar(30),
	UsgageMeasurementUnit nvarchar(10),
	TotalMeasurementUnit nvarchar(10)

	primary key (UserID_Doctor, CreationTime)
)

create table HEALTH_DIALY_RECORD
(
	UserID nvarchar(30),
	_Day Date,

	UsingTime float, -- hours
	HeartBeatAVG float,
	NegativeStatePct float,
	NormalStatePct float,
	PositiveStatePct float,

	primary key (UserID, _Day)
)

create table HEALTH_MONTHLY_RECORD
(
	UserID nvarchar(30),
	_Month Date,

	UsingTime float, -- hours
	HeartBeatAVG float,
	NegativeStatePct float,
	NormalStatePct float,
	PositiveStatePct float,

	primary key (UserID, _Month)
)

create table HEALTH_ANNUAL_RECORD
(
	UserID nvarchar(30),
	_Year Date,

	UsingTime float, -- hours
	HeartBeatAVG float,
	NegativeStatePct float,
	NormalStatePct float,
	PositiveStatePct float,

	primary key (UserID, _Year)
)

create table HEALTH_WARNINGS
(
	_Time date primary key,
	_content nvarchar(400)
)

--create table HEALTH_DIALY_RECORD
--(
--	UserID nvarchar(30),

--	_Day Date,
--	UsingTime float, -- hours

--	HeartBeatAVG float,

--	AngerEmotionPct float,
--	ContemptEmotionPct float,
--	DisgustEmotionPct float,
--	FearEmotionPct float,
--	JoyEmotionPct float,
--	SadnessEmotionPct float,
--	SupriseEmotionPct float,

--	NegativeSentimentPct float,
--	NeutralSentimentPct float,
--	PositiveSentimentPct float,

--	primary key (UserID, _Day)
--)

--create table HEALTH_MONTHLY_RECORD
--(
--	UserID nvarchar(30),

--	_Month Date,
--	UsingTime float, -- hours

--	HeartBeatAVG float,

--	AngerEmotionPct float,
--	ContemptEmotionPct float,
--	DisgustEmotionPct float,
--	FearEmotionPct float,
--	JoyEmotionPct float,
--	SadnessEmotionPct float,
--	SupriseEmotionPct float,

--	NegativeSentimentPct float,
--	NeutralSentimentPct float,
--	PositiveSentimentPct float,

--	primary key (UserID, _Month)
--)

--create table HEALTH_ANNUAL_RECORD
--(
--	UserID nvarchar(30),

--	_Year Date,
--	UsingTime float, -- hours

--	HeartBeatAVG float,

--	AngerEmotionPct float,
--	ContemptEmotionPct float,
--	DisgustEmotionPct float,
--	FearEmotionPct float,
--	JoyEmotionPct float,
--	SadnessEmotionPct float,
--	SupriseEmotionPct float,

--	NegativeSentimentPct float,
--	NeutralSentimentPct float,
--	PositiveSentimentPct float,

--	primary key (UserID, _Year)
--)

create table IP
(
	UserID nvarchar(30) primary key,
	Ip nvarchar(15)
)

go

alter table ACCOUNT_LINK
	add constraint FK_ACCOUNT_LINK_USERID_1_ACCOUNT_USERID
	foreign key (UserID_1)
	references ACCOUNT(UserID)

alter table ACCOUNT_LINK
	add constraint FK_ACCOUNT_LINK_USERID2_ACCOUNT_USERID
	foreign key (UserID_2)
	references ACCOUNT(UserID)

alter table RELATIVE_ACCOUNT
	add constraint FK_RELATIVE_ACCOUNT_USERID_ACCOUNT_USERID
	foreign key (UserID)
	references ACCOUNT(UserID)

alter table DOCTOR_ACCOUNT
	add constraint FK_DOCTOR_ACCOUNT_USERID_ACCOUNT_USERID
	foreign key (UserID)
	references ACCOUNT(UserID)

alter table PATIENT_ACCOUNT
	add constraint FK_PATIENT_ACCOUNT_USERID_ACCOUNT_USERID
	foreign key (UserID)
	references ACCOUNT(UserID)

alter table HEALTH_HISTORY
	add constraint FK_HEALTH_HISTORY_USERID_PATIENT_ACCOUNT_USERID
	foreign key (UserID)
	references PATIENT_ACCOUNT(UserID)

alter table HYPERSENSITIVITY_PHARMACY
	add constraint FK_HYPERSENSITIVITY_PHARMACY_USERID_PATIENT_ACCOUNT_USERID
	foreign key (UserID)
	references PATIENT_ACCOUNT(UserID)
	
alter table DIAGNOSIS_RESULT
	add constraint FK_DIAGNOSIS_RESULT_USERID_DOCTOR_DOCTOR_ACCOUNT_USERID
	foreign key (UserID_Doctor)
	references DOCTOR_ACCOUNT(UserID)

alter table DIAGNOSIS_RESULT
	add constraint FK_DIAGNOSIS_RESULT_USERID_PATIENT_PATIENT_ACCOUNT_USERID
	foreign key (UserID_Patient)
	references PATIENT_ACCOUNT(UserID)

alter table PRESCRIPTION
	add constraint FK_PRESCRIPTION_USERID_DOCTOR_DOCTOR_ACCOUNT_USERID
	foreign key (UserID_Doctor)
	references DOCTOR_ACCOUNT(UserID)

alter table PRESCRIPTION
	add constraint FK_PRESCRIPTION_USERID_PATIENT_PATIENT_ACCOUNT_USERID
	foreign key (UserID_Patient)
	references PATIENT_ACCOUNT(UserID)

alter table PRESCRIPTION_DETAIL
	add constraint FK_PRESCRIPTION_DETAIL_USERID_DOCTOR_CREATETIME_PRESCRIPTION_USERID_DOCTOR_CREATIONTIME
	foreign key (UserID_Doctor, CreationTime)
	references PRESCRIPTION(UserID_Doctor, CreationTime)
	
alter table HEALTH_DIALY_RECORD
	add constraint FK_HEALTH_DIALY_RECORD_USERID_PATIENT_ACCOUNT_USERID
	foreign key (UserID)
	references PATIENT_ACCOUNT(UserID)

alter table HEALTH_MONTHLY_RECORD
	add constraint FK_HEALTH_MONTHLY_RECORD_USERID_PATIENT_ACCOUNT_USERID
	foreign key (UserID)
	references PATIENT_ACCOUNT(UserID)

alter table HEALTH_ANNUAL_RECORD
	add constraint FK_HEALTH_ANNUAL_RECORD_USERID_PATIENT_ACCOUNT_USERID
	foreign key (UserID)
	references PATIENT_ACCOUNT(UserID)

alter table IP
	add constraint FK_IP_USERID_ACCOUNT_USERID
	foreign key (UserID)
	references ACCOUNT(UserId)

-- Store procedure
GO
CREATE PROCEDURE AISC_TEAM10_PROC_ACCOUNT_INSERT
	@Email nvarchar(50), @Sex nvarchar(6), @FullName nvarchar(30), @DoB Date,
	@UserPassword nvarchar(30), @UserID nvarchar(30), @UserAddress nvarchar(100),
	@Phone nvarchar(15)
AS
	insert into ACCOUNT(Email, Sex, FullName, DoB, UserPassword, UserID, UserAddress, Phone)
		values (@Email, @Sex, @FullName, @DoB, @UserPassword, @UserID, @UserAddress, @Phone)
GO

CREATE PROCEDURE AISC_TEAM10_PROC_RELATIVE_ACCOUNT_INSERT @UserID nvarchar(30)
AS
	insert into RELATIVE_ACCOUNT(UserID) values (@UserID)
GO

CREATE PROCEDURE AISC_TEAM10_PROC_PATIENT_ACCOUNT_INSERT @UserID nvarchar(30)
AS
	insert into PATIENT_ACCOUNT(UserID) values (@UserID)
GO

CREATE PROCEDURE AISC_TEAM10_PROC_DOCTOR_ACCOUNT_INSERT
	@UserID nvarchar(30), @HospitalName nvarchar(50), @WorkAddress nvarchar(50),
	@Speciality nvarchar(30)
AS
	insert into DOCTOR_ACCOUNT(UserID, HospitalName, WorkAddress, Speciality)
	 values (@UserID, @HospitalName, @WorkAddress, @Speciality)
GO

--------------------------------
CREATE PROCEDURE AISC_TEAM10_PROC_LOGIN
	@UserID nvarchar(30),@UserPassword nvarchar(30), @Succeed int output
AS
	set @Succeed = -1

	if (not exists
		(select * from ACCOUNT acc 
		where acc.UserID = @UserID and acc.UserPassword = @UserPassword)
	)
	begin
		return
	end
	if (exists
		(select * from PATIENT_ACCOUNT acc
		where acc.UserID = @UserID)
	)
	begin
		set @Succeed = 0
	end
	else if ( exists
			(select * from DOCTOR_ACCOUNT acc
			where acc.UserID = @UserID)
	)
	begin
		set @Succeed = 1
	end
	else if (exists
			(select * from RELATIVE_ACCOUNT acc
			where acc.UserID = @UserID)
	)
	begin
		set @Succeed = 2
	end
GO

CREATE PROCEDURE AISC_TEAM10_PROC_GET_ACCOUNT_INFO
	@UserID nvarchar(30)
as
	select * from ACCOUNT acc where acc.UserID = @UserID
go

CREATE PROCEDURE AISC_TEAM10_PROC_GET_RELATIVE_ACCOUNT_INFO
	@UserID nvarchar(30)
as
	select * from ACCOUNT acc join RELATIVE_ACCOUNT rel on acc.UserID = rel.UserID
	where acc.UserID = @UserID
go

CREATE PROCEDURE AISC_TEAM10_PROC_GET_DOCTOR_ACCOUNT_INFO
	@UserID nvarchar(30)
as
	select * from ACCOUNT acc join DOCTOR_ACCOUNT doc on acc.UserID = doc.UserID
	where acc.UserID = @UserID
go

CREATE PROCEDURE AISC_TEAM10_PROC_GET_PATIENT_ACCOUNT_INFO
	@UserID nvarchar(30)
as
	select * from ACCOUNT acc join PATIENT_ACCOUNT pat on acc.UserID = pat.UserID
	where acc.UserID = @UserID
go

CREATE PROCEDURE AISC_TEAM10_PROC_UPDATE_IP
	@UserID nvarchar(30), @Ip nvarchar(15)
as
	if (exists
		(select * from IP where IP.UserID = @UserID and IP.Ip = @Ip)
	)
	begin
		return
	end

	insert into IP(UserID, Ip) values (@UserID, @Ip)
go

CREATE PROCEDURE AISC_TEAM10_PROC_RELEASE_IP
	@UserID nvarchar(30)
as
	delete from IP where IP.UserID = @UserID
go

CREATE PROCEDURE AISC_TEAM10_PROC_GETALL_IP_ONLINE_LINKED_ACC
	@UserID nvarchar(30)
as
	select ip.UserID, ip.Ip
	from ACCOUNT_LINK acc join IP ip on acc.UserID_1 = ip.UserID or acc.USerID_2 = ip.UserID
	where (acc.UserID_1 = @UserID or acc.USerID_2 = @UserID)
		and ip.UserID != @UserID
		and acc._state = 1 -- alread linked
go

-- nếu A -> B mà có B -> A thì accept
CREATE PROCEDURE AISC_TEAM10_PROC_INSERT_LINKING_REQUEST
	@UserID_1 nvarchar(30), @UserID_2 nvarchar(30)
as
	if (@UserID_2 in
		(select accLink.USerID_2 from ACCOUNT_LINK accLink where accLink.UserID_1 = @UserID_1)
	)
	begin
		return
	end

	if (
		@UserID_2 in
		(select accLink.USerID_1 from ACCOUNT_LINK accLink where accLink.UserID_2 = @UserID_1)
	)
	begin
		exec AISC_TEAM10_PROC_ACCEPT_LINKING_REQUEST @UserID_2, @UserID_1
		return
	end

	insert into ACCOUNT_LINK(UserID_1, USerID_2, _state) values (@UserID_1, @UserID_2, 0)
go

CREATE PROCEDURE AISC_TEAM10_PROC_ACCEPT_LINKING_REQUEST
	@UserID_1 nvarchar(30), @UserID_2 nvarchar(30)
as
	update ACCOUNT_LINK set _state = 1
	where UserID_1 = @UserID_1 and USerID_2 = @UserID_2
go

CREATE PROCEDURE AISC_TEAM10_PROC_UNLINK_ACCOUNT
	@UserID_1 nvarchar(30), @UserID_2 nvarchar(30)
as
	delete from ACCOUNT_LINK 
	where _state = 1 and
		( (@UserID_1 = UserID_1 and @UserID_2 = UserID_2)
			or
		  (@UserID_1 = UserID_2 and @UserID_2 = UserID_1)
		)
go

CREATE PROCEDURE AISC_TEAM10_PROC_GETALL_LINKING_REQUEST
	@UserID nvarchar(30)
as
	select USerID_1 as 'UserID' from ACCOUNT_LINK 
	where UserID_2 = @UserID and _state = 0
go

CREATE PROCEDURE AISC_TEAM10_PROC_GETALL_LINKED_ACCOUNTS
	@UserID nvarchar(30)
as
	select USerID_1 as 'UserID' from ACCOUNT_LINK 
	where UserID_2 = @UserID and _state = 1
	union
	select USerID_2 as 'UserID' from ACCOUNT_LINK 
	where UserID_1 = @UserID and _state = 1
go

CREATE PROCEDURE AISC_TEAM10_PROC_GET_HEALTH_WARNINGS
as
	Select top 1 * from HEALTH_WARNINGS
	order by _Time desc
go

CREATE PROCEDURE AISC_TEAM10_PROC_UPDATE_HEALTH_DIALY_RECORD
	@UserId nvarchar(30), @Day date, @UsingTime float,
	@HeartBeat float,
	@Negative float, @Normal float, @Positive float
as
	if (not exists
		(select * from HEALTH_DIALY_RECORD dialy
		where dialy.UserID = @UserId and dialy._Day = @Day)
	)
	begin
		insert into HEALTH_DIALY_RECORD(UserID, _Day, UsingTime, HeartBeatAVG, 
			NegativeStatePct, NormalStatePct, PositiveStatePct)
		values
			(@UserId, @Day, @UsingTime,	@HeartBeat,
				@Negative, @Normal, @Positive)
		return
	end

	Declare @_oldUsingTime float
	Declare @_newUsingTime float
	Declare @_hrAVG float
	Declare @_negative float
	Declare @_normal float
	Declare @_positive float

	select @_OldUsingTime = dialy.UsingTime
	from HEALTH_DIALY_RECORD dialy
	where dialy.UserID = @UserId and dialy._Day = @Day

	set @_newUsingTime = @_oldUsingTime + @UsingTime
	
	select @_hrAVG = (dialy.HeartBeatAVG * @_oldUsingTime + @HeartBeat * @UsingTime) / @_newUsingTime
	from HEALTH_DIALY_RECORD dialy
	where dialy.UserID = @UserId and dialy._Day = @Day

	select @_negative = dialy.NegativeStatePct + @Negative
	from HEALTH_DIALY_RECORD dialy
	where dialy.UserID = @UserId and dialy._Day = @Day

	select @_normal = dialy.NormalStatePct + @Normal
	from HEALTH_DIALY_RECORD dialy
	where dialy.UserID = @UserId and dialy._Day = @Day

	select @_positive = dialy.PositiveStatePct + @Positive
	from HEALTH_DIALY_RECORD dialy
	where dialy.UserID = @UserId and dialy._Day = @Day
	
	update HEALTH_DIALY_RECORD
	set UsingTime = @_newUsingTime,
		HeartBeatAVG = @_hrAVG,
		NegativeStatePct = @_negative,
		NormalStatePct = @_normal,
		PositiveStatePct = @_positive
	where UserID = @UserId		
go

--CREATE PROCEDURE AISC_TEAM10_PROC_UPDATE_HEALTH_DIALY_RECORD
--	@UserId nvarchar(30), @Day date, @UsingTime float,
--	@HeartBeat float,
--	@Anger float, @Contempt float, @Disgust float,
--	@Fear float, @Joy float, @Sadness float, @Suprise float,
--	@Negative float, @Neutral float, @Positive float
--as
--	if (not exists
--		(select * from HEALTH_DIALY_RECORD dialy
--		where dialy.UserID = @UserId and dialy._Day = @Day)
--	)
--	begin
--		insert into HEALTH_DIALY_RECORD(UserID, _Day, UsingTime, HeartBeatAVG, 
--			AngerEmotionPct, ContemptEmotionPct, DisgustEmotionPct,
--			FearEmotionPct, JoyEmotionPct, SadnessEmotionPct, SupriseEmotionPct, 
--			NegativeSentimentPct, NeutralSentimentPct, PositiveSentimentPct)
--		values
--			(@UserId, @Day, @UsingTime,	@HeartBeat,
--				@Anger, @Contempt, @Disgust,
--				@Fear, @Joy, @Sadness, @Suprise,
--				@Negative, @Neutral, @Positive)

--		return
--	end

--	declare 
--go