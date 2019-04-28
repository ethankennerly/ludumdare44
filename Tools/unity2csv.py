"""
To import yaml, install PyYaml.

https://stackoverflow.com/questions/33665181/how-to-install-pyyaml-on-windows-10
"""
import csv
import sys
import os
import yaml

def realpath(path):
    script_path = os.path.dirname(os.path.realpath(__file__))
    return os.path.join(script_path, path)


sys.path.append(realpath('vlad_dumitrascu'))
import unity2yaml


def create_csv_writer(fieldnames):
    writer = csv.DictWriter(sys.stdout,
        fieldnames=fieldnames,
        quoting=csv.QUOTE_MINIMAL,
        lineterminator='\n')
    writer.writeheader()
    return writer


def load(path):
    yaml_string = unity2yaml.removeUnityTagAlias(path)
    yaml_object = yaml.safe_load(yaml_string)
    return yaml_object


if '__main__' == __name__:
    if len(sys.argv) < 2:
        print('Usage: python unity2csv.py yaml_file [yaml_file...]')
        sys.exit(0)
    paths = sys.argv[1:]
    path = paths[0]
    yaml_object = load(path)
    writer = create_csv_writer(yaml_object.keys())
    for path in paths:
        yaml_object = load(path)
        writer.writerow(yaml_object)
