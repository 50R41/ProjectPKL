LANGKAH PENGINSTALAN :
1. Gunakan SQL SERVER
2. Buatlah Database yang namanya PKL
3. Lalu run script "DatabasePKL.sql" di sql servernya ( SSMS )
4. jalankan aplikasi di ProjectQueenalya\bin\Debug


SARAN PEMAKAIAN :
Untuk di bagian pas print datagridviewnya tolong kalau bisa di kecilin dulu size MainForm dan Prefrencenya di landscape kan agar hasil printnya bagus . .


UNTUK SQL SERVER AGENT JOBS || QUERYNYA :

INSERT INTO Absen(kehadiran, tanggal , nama_siswa ) SELECT 'Alfa' , GETDATE() , nama FROM Siswa WHERE NOT EXISTS(SELECT 1 FROM Absen WHERE tanggal = CAST(GETDATE() as DATE))
GO



NOTE :
Abaikan saja reference yang enggak kepake nya  . . . soalnya itu gak di pake sih . . jadi terserah XD


Follow me on :
Instagram	: @gwyncharwyniv_
Github		: https://github.com/50R41
