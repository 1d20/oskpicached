from django.shortcuts import render, redirect, get_object_or_404
from django.core.cache import cache
from .models import FileStorage


def home(request):
    res = {'files': FileStorage.objects.all()}
    return render(request, 'home.html', res)


def get(request, file_id):
    if not cache.get(str(file_id)):
        f = get_object_or_404(FileStorage, pk=file_id)
        cache.set(str(file_id), f, 50)
        print 'cached'
    return redirect(cache.get(str(file_id)).f.url)
