import http from "k6/http";
import { sleep } from "k6";

export const options = {
  stages: [
    { duration: "2m", target: 2000 },
    { duration: "1m", target: 0 },
    { duration: "2m", target: 2000 },
    { duration: "1m", target: 0 },
  ],
  thresholds: {
    http_req_failed: ["rate<0.01"], // http errors should be less than 1%
    http_req_duration: ["p(95)<500"], // 95 percent of response times must be below 500ms
  },
};

export default function () {
  http.get("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator");
  sleep(1);
}
