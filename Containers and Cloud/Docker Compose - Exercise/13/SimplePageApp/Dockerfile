FROM python:3.9-slim

WORKDIR /app

ENV PYTHONDONTWRITEBYTECODE=1
ENV PYTHONUNBUFFERED=1

COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

COPY . .

RUN mkdir ./staticfiles
COPY ./static ./staticfiles

EXPOSE 8000

CMD [ "gunicorn", "SimplePageApp.wsgi:application", "--bind", "0.0.0.0:8000" ]