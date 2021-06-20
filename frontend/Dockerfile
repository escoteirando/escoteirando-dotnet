FROM node:alpine

RUN yarn global add @quasar/cli

WORKDIR /app

COPY quasar.conf.js /app/
COPY package.json /app/

RUN yarn install

COPY . /app

RUN quasar build

