#include<stdio.h>
#include<stdlib.h>
#include<WinSock2.h>
#include"opencv2/core/core.hpp"
#include<opencv2/highgui/highgui.hpp>

#define BUFSIZE 256

#pragma comment(lib,"ws2_32")

using namespace cv;
 
void error_handling(char *msg) {
	printf("%s \n", msg);
	exit(1);
}


int main(int argc, char **argv)
{
	WSADATA wsaData;
	SOCKET s_fd, c_fd;
	SOCKADDR_IN serv_addr, clnt_addr;
	int clnt_sz;
	char msg[] = "SONG JANG YOI :";

	FILE *fp;
	/*	if (argc != 2) {
			printf("Usage : %s <PORT> \n", argv[0]);
			exit(1);
		}
		*/

	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0) {} //WinSock reset
		//error_handling("WSAStartup() Error!");
	s_fd = socket(AF_INET, SOCK_STREAM, 0);// Socket create
	if (s_fd == INVALID_SOCKET)    // socket error occure INVALID_SOCKET = -1
		printf("1");

	//error_handling("SOCKET() Error!");.

	char buf[BUFSIZE + 1];
	char *pBuf;

	int retval;

	memset(&serv_addr, 0x00, sizeof(serv_addr));
	serv_addr.sin_family = AF_INET;
	serv_addr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_addr.sin_port = htons(3300);

	if (bind(s_fd, (struct sockaddr *)&serv_addr, sizeof(serv_addr)) == SOCKET_ERROR)
		printf("2");
	//error_handling("Bind() Error!");
	printf("bind\n");
	if (listen(s_fd, 5) == SOCKET_ERROR)
		printf("3");
	//error_handling("Listen() Error!");
	printf("listen\n");
	clnt_sz = sizeof(clnt_addr);
	c_fd = accept(s_fd, (struct sockaddr *)&clnt_addr, &clnt_sz); printf("accept\n");
	if (c_fd == INVALID_SOCKET)
		printf("4");
	//error_handling("Accept() Error!");

	cv::Mat img;
	img = cv::Mat::zeros(1920, 1180, CV_8UC1);
	int imgSize = img.total() * img.elemSize();
	uchar *iptr = img.data;
	int i = 0;
	fp = fopen("test.txt", "w");
	int y = 1;
	//recv(c_fd, (char*)iptr, sizeof(&iptr), MSG_WAITALL);//sizeof(msg), 0); //얘는 받는 기능설정 (while 문으로 하면 계속 받을 수 있다^^)
while(y){
	while (1) {
		retval = recv(c_fd, buf, BUFSIZE, 0);   //0 은 모드.
		/*if (retval == SOCKET_ERROR) {
			//printf("recv()");
			break;
		}
		*/
		if (retval == 0)
			break;
		
		if (*buf != NULL) {

			//buf[retval] = '\0';
			if (i <= 320) {
				fprintf(fp, "%s,", buf);
		 		printf("%s", buf);
				printf(",");
				i++;
			}
			else if (i > 320) {
				fprintf(fp, "%s,\n", buf);
				printf("%s\n", buf);
				printf(",");
				printf("\n");
				i = 0;
			}

		}
	}
	if (y == 6) {
		break;
	}
	y++;
	
}

		

	//printf("%d", iptr);// 얘가 있어야 출력이 된다.글쓰는 역할

	closesocket(c_fd);
	closesocket(s_fd);
	WSACleanup();
	return 0;
}