import http from "k6/http";
import { sleep } from "k6";

export const options = {
  stages: [
    { duration: "2m", target: 2000 },
    { duration: "1m", target: 0 },
    { duration: "2m", target: 2000 },
    { duration: "1m", target: 0 },
  ],
};

export default function () {
  http.get("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator");
  sleep(1);
}
