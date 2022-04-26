const XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
const WebClient = require('javascript-web-client');
const myApiWebClient = new WebClient('https://www.quotepub.com/api/widget/?type=qotd_t');
//var json_obj = JSON.parse('{"quote_body":"In a universe that\'s an intelligent system with a divine creative force supporting it, there simply can be no accidents. As tough as it is to acknowledge, you had to go through what you went through in order to get to where you are today, and the evidence is that you did.","quote_author":"Wayne Dyer","quote_vendor":"https:\/\/www.quotepub.com\/"}');

let json_obj = " ";
let request = new XMLHttpRequest();
request.open('GET', 'https://www.quotepub.com/api/widget/?type=qotd_t');
request.send;
request.onload = () => {
  json_obj = JSON.parse(request.response);
}

  //var json_obj = JSON.parse('{"quote_body":"A major part of love is commitment. If we are committed to someone, if Im committed to loving you, then its not possible for me to fall out of love.","quote_author":"bell hooks","quote_vendor":"https:\/\/www.quotepub.com\/"}');
  console.log(quote_body = json_obj.quote_body);
  let quote_author = json_obj.quote_author;