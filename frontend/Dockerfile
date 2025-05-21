FROM node:23.11.1-alpine3.21

RUN yarn global add @quasar/cli

WORKDIR /app

COPY quasar.conf.js /app/
COPY package.json /app/

RUN yarn install

COPY . /app

RUN quasar build

