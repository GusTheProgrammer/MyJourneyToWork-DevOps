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
};

export default function () {
  http.get("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator");
  sleep(1);
}
