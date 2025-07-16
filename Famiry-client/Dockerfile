FROM node:22-slim
WORKDIR /app

RUN npm install -g npm@8.12.1

COPY ./Famiry-client/package*.json ./
RUN npm install

COPY ./Famiry-client .
#RUN npm run build

EXPOSE 8080

CMD [ "npm", "run", "dev" ]