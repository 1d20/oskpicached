from django.db import models


class FileStorage(models.Model):
    f = models.FileField(upload_to="files")

    def __unicode__(self):
        return str(self.f)
