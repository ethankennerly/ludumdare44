"""
Usage:

    Edit cfg in unity2csv.py

    python unity2csv.py yaml_file [yaml_file...] > output.csv

Example:

    python ../../../../Tools/unity2csv.py ../../Resources/Level_0.asset > ../../Texts/level_0.csv

To import yaml, install PyYaml.

Example from command line:

        pip install PyYAML-3.13-cp27-cp27m-win32.whl

https://stackoverflow.com/questions/33665181/how-to-install-pyyaml-on-windows-10
"""

cfg = {
    'parent_key': 'MonoBehaviour',
    'fieldnames': ['m_Name', 'word', 'answers', 'validWords'],
    'extract_number_fieldnames': ['m_Name']
}


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


def load(path, parent_key, filter_keys = None):
    yaml_string = unity2yaml.removeUnityTagAlias(path)
    yaml_object = yaml.safe_load(yaml_string)
    if parent_key not in yaml_object:
        raise 'Usage: Expected %r key in file %r' % (parent_key, path)
    child_object = yaml_object[parent_key]
    if filter_keys:
        child_object = filter_dictionary(child_object, filter_keys)
    return child_object


def filter_dictionary(source_dictionary, keys):
    filtered = {}
    for key in keys:
        filtered[key] = source_dictionary[key]
    return filtered


def extract_number(dictionary, keys):
    for key in keys:
        text = dictionary[key]
        digits = parse_digits(text)
        if digits == '':
            raise 'Expected digit in %r' % text
            continue
        dictionary[key] = digits


def parse_digits(text):
    digits = int(''.join(
        d for d in text
            if d.isdigit()))
    return digits


if '__main__' == __name__:
    if len(sys.argv) < 2:
        print(__doc__)
        sys.exit(0)
    paths = sys.argv[1:]
    path = paths[0]
    writer = create_csv_writer(cfg['fieldnames'])
    for path in paths:
        yaml_object = load(path, cfg['parent_key'], cfg['fieldnames'])
        extract_number(yaml_object, cfg['extract_number_fieldnames'])
        writer.writerow(yaml_object)
