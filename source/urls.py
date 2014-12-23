from django.conf.urls import patterns, include, url
from django.contrib import admin
from django.conf.urls.static import static
import settings

urlpatterns = patterns(
    '',
    url(r'^$', 'core.views.home', name='home'),
    url(r'^get/(?P<file_id>\d+)/$', 'core.views.get', name='get'),

    url(r'^admin/', include(admin.site.urls)),
)

urlpatterns += static(settings.STATIC_URL, document_root=settings.STATIC_ROOT)
urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)
