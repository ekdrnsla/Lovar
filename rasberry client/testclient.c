#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/socket.h>

#define MAXLINE 30

int main(int argc, char *argv[]){
  struct sockaddr_in serv_addr;
  int sock;
  int str_len;
  char message[MAXLINE];
  
  sock = socket(AF_INET, SOCK_STREAM, 0);
  memset(&serv_addr, 0, sizeof(serv_addr));

  serv_addr.sin_family = AF_INET;
  serv_addr.sin_addr.s_addr=inet_addr(argv[1]);
  serv_addr.sin_port=htons(atoi(argv[2]));

  str_len=read(sock, message, sizeof(message)-1);

  close(sock);
  sleep(10000);
  return 0;
}
