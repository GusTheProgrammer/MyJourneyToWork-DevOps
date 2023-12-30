import http from "k6/http";
import { sleep } from "k6";

export let options = {
  stages: [
    { duration: "30s", target: 50 },
    { duration: "1m", target: 50 },
    { duration: "30s", target: 100 },
    { duration: "1m", target: 100 },
    { duration: "30s", target: 200 },
    { duration: "1m", target: 200 },
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
