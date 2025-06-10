# Load environment variables from .env
set -a
source .env
set +a

# Init the db
docker compose exec influxdb influx setup \
  --username "$INFLUXDB_INIT_USERNAME" \
  --password "$INFLUXDB_INIT_PASSWORD" \
  --org "$INFLUXDB_ORG" \
  --bucket "$INFLUXDB_BUCKET" \
  --force

# Create the user
docker compose exec influxdb influx user create \
    --name "$INFLUXDB_USERNAME" \
    --password "$INFLUX_USER_PASSWORD" \
    --org "$INFLUXDB_ORG"

# Create a token for the new user (requires admin privileges)
docker compose exec influxdb influx auth create \
    --user "$INFLUXDB_USERNAME" \
    --org "$INFLUXDB_ORG" \
    --write-buckets \
    --read-buckets