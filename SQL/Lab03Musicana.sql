
CREATE TABLE musician (
    m_id SERIAL PRIMARY KEY,
    m_name VARCHAR(100),
    m_phone VARCHAR(15),
    m_city VARCHAR(50),
    m_street VARCHAR(50)
)

CREATE TABLE instrument (
    i_name VARCHAR(50) PRIMARY KEY,
    musical_key VARCHAR(10)
)

CREATE TABLE album (
    album_id SERIAL PRIMARY KEY,
    album_title VARCHAR(100),
    album_date DATE,
    m_id INT,
    FOREIGN KEY (m_id) REFERENCES musician(m_id)
)

CREATE TABLE song (
    song_title VARCHAR(100) PRIMARY KEY,
    author VARCHAR(100),
    album_id INT,
		FOREIGN KEY (album_id) REFERENCES album(album_id)
)

CREATE TABLE musician_instrument (
    m_id INT,
    i_name VARCHAR(50),
    PRIMARY KEY (m_id, i_name),
    FOREIGN KEY (m_id) REFERENCES musician(m_id),
    FOREIGN KEY (i_name) REFERENCES instrument(i_name)
)

CREATE TABLE musician_song (
    m_id INT,
    song_title VARCHAR(100),
    PRIMARY KEY (m_id, song_title),
    FOREIGN KEY (m_id) REFERENCES musician(m_id),
    FOREIGN KEY (song_title) REFERENCES song(song_title)
)