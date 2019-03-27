#include <opencv2/core/core.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/opencv.hpp>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <unistd.h>
using namespace std;
using namespace cv;
#define BUF_LEN 128
#define DEST_IP "192.168.1.18"
int main()
{
  Mat img1 = imread("image.jpg", 0);
  Mat img2 = imread("image2.jpg", 0);
  resize(img1, img1, Size(), 0.3, 0.3);
  resize(img2, img2, Size(), 0.3, 0.3);

  int width = img1.size().width;
  int height = img1.size().height;

  Mat output(height, width, CV_8UC1);
  Mat dst; 
  for (int y = 0; y < height; y++)
  {
    for (int x = 0; x < width; x++)
    {
       
      output.at<uchar>(y, x) = abs(img1.at<uchar>(y, x) - img2.at<uchar>(y, x));
    }
  }

  threshold(output,dst,50,255,THRESH_BINARY);
//  imshow("thresh",dst);
//  imshow("sub Image", output);

 fastNlMeansDenoising(dst, dst, 3, 7, 21);
// imshow("fast", dst);

 imwrite("testimg.jpg",dst);
printf("1");
  int s,n;
  char *haddr;
  struct sockaddr_in server_addr;
  char buf[BUF_LEN+1];


  if((s=socket(PF_INET, SOCK_STREAM, 0))<0){
    printf("can't create socket\n");
    exit(0);
  }
printf("2");
  bzero((char *)&server_addr, sizeof(server_addr));
  server_addr.sin_family = AF_INET;
  server_addr.sin_port=htons(3300);
  server_addr.sin_addr.s_addr=inet_addr(DEST_IP);

  if(connect(s, (struct sockaddr *)&server_addr, sizeof(server_addr))<0){
    printf("can't connect .\n");
    exit(0);
  }
//  int imageSize=dst.total()*dst.elemSize();
// send(s, dst.data, imageSize,0);
// char message[]=(char)dst;
//  write(s, dst, sizeof(dst));

  
  Rect roi(0, 0, dst.size().width ,dst.size().height );
  Mat roi_img=dst(roi);
  for(int i=0; i<roi_img.rows;i++){
    for(int j=0; j<roi_img.cols; j++){
      cout.width(5);
      
      cout<<(int)roi_img.at<uchar>(i,j);
     // send(s,(int)roi_img.at<uchar>(i,j),sizeof(uchar),0);
      
     send(s, roi_img.data,sizeof(1000),0);
    }
    cout<<endl;
  }
  rectangle(dst, roi, Scalar(255), 1);


  close(s);
  

}

