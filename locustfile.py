from locust import HttpUser, task
class LoadUser(HttpUser):
    @task
    def load(self):
        self.client.get("/character", verify=False)
