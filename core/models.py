from django.db import models
from random import randint

class FileStorage(models.Model):
    f = models.FileField(upload_to="files")

    def __unicode__(self):
        return str(self.f)

    def icon(self):
    	# print random.randint(0,129)
    	return randint(0,129)