import http from "k6/http";
import { sleep } from "k6";

export const options = {
  duration: "5m",
  vus: 50,
};

export default function () {
  http.get("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator");
  sleep(1);
}
