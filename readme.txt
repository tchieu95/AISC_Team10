- Module sử dụng trên kiến trúc x64 nên code thì build trên platform x64. Nhưng khi làm vậy, các form và usercontrol sẽ không hiện ra. Vì thế khi design thì làm ở chế độ "AnyCPU", khi chạy thì build ở "x64".
- Emotion detection: một số cảm xúc rất khó xuất hiện do người dùng làm không đủ để realsense ghi nhận.
- Heart Rate:
	* Khoảng cách lý tưởng: ~50 - 80cm.
	* Phải chờ ổn định khoảng 30s thì realsense mới ghi nhận chính xác nhịp tim, trong thời gian ổn đỉnh phải chờ tất quả các kết quả ghi nhận đều ra 0 hoặc -1.