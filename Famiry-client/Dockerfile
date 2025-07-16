FROM node:22-slim
WORKDIR /app

RUN npm install -g npm@8.12.1

COPY ./Famiry-client/package*.json ./
RUN npm install

COPY ./Famiry-client .
#RUN npm run build

EXPOSE 5173  

CMD ["npm", "run", "dev", "--", "--host", "0.0.0.0"]  