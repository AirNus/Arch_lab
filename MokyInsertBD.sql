

use Arch_lab




	select * from email

	SET IDENTITY_INSERT email OFF

	insert into email (id,dated,IdSender,Data,Signature,IdReceiver,Status)
	select 99,getdate(),2,'Test moky text','
äré.**-KÛÿ<‡Ý!®ð¤)~#SÑKÒúkQí|y6µÑy¤ß­µ¤àèoˆþ|D«Ot£¦<þ—î‘íìœü£²!÷à°TgÇVbSö‰‰s›yHÅ9¶ŒZ*ÌÊ½ÀÁæ×y¸rÉe¨Í’‹Êt² »#Š<Ã8øýáþ$¾XŒ™_R«N-m°ZÍ,]ä×}rMC?^ê¸m<v	x6c“6ÏŠôT(²€•´·ø`t¨äÅGzŠŽœäÿTí¿l‚''AM—×În.~¿0Å§÷êdÐÜ§*hª€¢qÓ›’*„7(Ò3yÔÐ*‚Á­B®',1,2



	select * from privateKey

	SET IDENTITY_INSERT privatekey OFF


	insert into privatekey (id, [Key], Actual)
	select 1,'{"Exponent":"AQAB","Modulus":"vBD2g8q6s4cWwlcEIkUm4vC8kEGyq6L53IiGwkA3sDyA6FIehECVFdTv6PJq9LuNJQtnBAPxsHC5ln5vmxb3CLM/2xFRVyZv/YZTTkEQKjtv4II+9l7/m8ohPSeIXwlaE22bBGRT9xQGj5+v9sA7j+V0D4wso7CoszbFXHCQfoeEnZewQ8BddoqFkCoY/1zd1BSiNlOrtBOCdbw8z09fmt2jn4bIIqEINqVaclMs1ZfjSyNcdZfiTo2lGqc6UuB7gnWnClHQgSq22qOIb/imS09OAgBkb60uKxpSVvHOVOR1byfoRZvlp3GAF6vCTrJUAmhTfAomATNSsyZ2tKcBuQ==","P":"yzNi1aoaonZI99UOCSQxbDhJLLyfSUirhtuUzapkkIQjzPIEG6WNuUP+39QHRue0NLVdhJGNQySBQ+wsi5Ur6IhK5w7XVp9coJGz9TJFf7Hmthu/iTWk14u7rj6Aqa+TDbJwKBXJgBtZn17q6BwYzxi1TfocqEAlItWpW95sJXs=","Q":"7O7avnUhB0Rh+skCv7+Uff6w3PdV9SSallHMJyazjWYWXqOkUshZPg9MazRXYNTh3HoL2wFCZS+NM3+iW1TQCosoHRXMob/a8hNFw4y/2RMa0QxxNhDqACok+N2ts4OT6xVMyGcMo88+EGfQ8NQi0P+JOzEi8MOINfQfQ3BIXVs=","DP":"uW2qCmrRJWIlkitVRJhHlYcDl5SFEt4C0Oy+LLQKUyqSdOqBPy1jWCYpht24ykaU1uiOb3RXYWcFoxL5T2MQD4GYQKP1c/G3GDv96Yo3i6CvdY16yt4uEBhOa2JUDQTQf9ZOrPW8zG+o6Fs4qBlDtnDIumC8F/l5KgGqK9CcBdM=","DQ":"K0RzLdS1813JhsKufdW+iEO6iJ+iUuIcWNcXMQ8gOvIpo56+o19y7KJekjU8v7IgjOK8x4GzXkcQwhbMz2DtnP9MlAMnG2Kt2Qcr9kn9vuZ+Py7GfdkY4m7P0aKp1d5xZLy/CNnItSFjdBuBTHlw4jnIFccjWlRay3+JNgeLL4E=","InverseQ":"xn5VHLWupMkmY4NtELgRi5cmzD1HRnAwp+ZFjk7+upk+6mLzoZwATCkeUsdFWPW/6Tu9TngAoGyCW2fuhScC2YhNgU+eXhhsH0RuNsqJ8Srr15m7oFRsNd4XjFfBQXFDLifiK/JM69IwSyHdNgHlA0XaELv3pQ5Au3m4VsW5X78=","D":"jD/yNzK2rS+vL1sJQC1l5JQ3azUzc4Bk6av/I1oUrZ9RWu/yxhoLlG5qQ8SVMtGzXs70EjCGy1glby/3NyeXLqvOkSaHDIEjv2OvOIqY7YXJ1xoKrl0GLj49L4gN0SH+RMLWeh3/6CDNC8rAxTlyscsiFH4qxB/4jz3nTRq9Bz3s0ojOuAUmrJL82QM7lHesUZsF5SNaRxTh1WYNeG3o1TvzRxjEuVyRP5toJ1Is+As9j2PSTaWYZ1D01pGJEo5rmK3UoYhVyGu0szhiJMotJF1YUBLkTpfLTjylj3s1IT5Yednx0452/slI6zMfTE0luxlTQZDsOBzz1K8g9Ww0aQ=="}',1
	union
	select 2,'{"Exponent":"AQAB","Modulus":"vbkbeXVIeK1JgMQpwfwmgWMCsMHAWIl0PdXSK62lQ0c/3iCt9AFduSNK3FZiv0kVc/Hx5vNBzFhB+BHah15shRqyFuO9zLGuBjB6bhcYkJ2/Z+yUI36PNgtBEofPGQzeIwRtdDRiBHs1EB0NFz/M45sdAi7Wm6VYUFSObx3J0EGt83rcSTMOU8U/lm/V3qT2NNlrxop0q3d4rGDgnBMi4OVopedT4V1uthVNuvTj8R09pynbCOwJDROvR+4VIrn03+th+lCgFWj3ms5xo8dCBK7SZsmaoSMU81zWAY73xzCgVK4vGHNxvBfOX7pgnhuzjKGSpFE5TIxVtAUdLyJGCQ==","P":"zHiAaAcXHvblEUh/xFCqjruLx7STg6k1wCCUvADZgrDLOgd4RUSXTCaDZ68H357w+RbPhvO9yQEdBw8IZYi2HuSQuEvj++mZhgZly97Yi5og2+vLSXqXSMzm28G2f+lZJS0raQtdvPOa6zoGvPi2rl5vreC5nQ/zlw/Ejh0eyrM=","Q":"7YkoNBcr9OvJJhHQzlNN/JnZc6QXCwy2dmFFM0nPdDiDzyJk74Vm1Mxe6eCOg2KPDHDubG15W7qzARLafrsTJ+jhmMEJZQsSocCP4ZjAfjHgU0XZe9HASDbDXt6NR/OHgRI9mtYBrGFVFgPaYmynRyApM+P47pO87Lzm8Y/eOlM=","DP":"pxgOr3Sj420Ws3IQ36igSTZgu5oJNv4v68t0YNM87X13BvwVwF2WWufaWQADqi5kdNq8S2ei/8GGLD+PuBHp6wMUdVenfzVefdV6mQmK40LYeYCPR4QEX7z7KDl837kdXbE1GYntV72oK3TnDsUd3Q9Vqr3MUds4UInVMeIASNs=","DQ":"Im292Qb+xQoj5pOweydR52n5Payr9lsKW1Av8oYhPowudqhajuj8BZ31p9p3bY2shDYeKLMZYvVFmsM7ziCZXzB++mAIV4/qTG2XrTAxvljGVeuK4Up+nzjoymhhe+tNWaTmLvoT1gNpjL5UOe3btRBxSGcjnpjlSj77Dko3AKc=","InverseQ":"pA9l65qjX4cs8dH7+KV3sNByWmjPov/Y+jG7ioNgo/+EZBCJnZX3/iR6lwY+FRqSEk5oKyy+i8dFka5gBDlPvQNTXTh9QOyOhBTXJwi1j+RXXuAuXpqsEkXLMm6HjHK6ovMKH9XdzcVoN6f8y9Ext+V0VVoDbB0OTpV2S9bVt/I=","D":"SqdYBEb+KV4mmiCWPdq2XBtVp6/VvAD6WIqWlNFTQlH687DwQh93fa5BesoTOSnM4z7E7RezQHFKJA8CalnhYc7LXO5odO9FhvH0evVjmSQ5eO9Cq2TVfXKYPG5sM3M4xZasaxlhqFnC24BS8l8MhFM46u77S2uYgKOFGHwkOWmw1+rfjQW5Cl8Bwoaasa++rgbON63uktwlQQ6wTlT00Au/rtNcwJmjw7eAOqCJI8A9oT+YfAlV/hQc5X9pz4/tLx+sZXy0DnG9ZaLaLnhRbxwEKJlByIf8dolVUsd/JzgpM81v39BmLhEfSr5uR6GB84u/7X5G3zcANYSx0dBO8Q=="}',1


	select * from PublicKey 

	SET IDENTITY_INSERT PublicKey OFF

	insert into PublicKey (id, [key], Actual)
	select 1,'{"Exponent":"AQAB","Modulus":"vBD2g8q6s4cWwlcEIkUm4vC8kEGyq6L53IiGwkA3sDyA6FIehECVFdTv6PJq9LuNJQtnBAPxsHC5ln5vmxb3CLM/2xFRVyZv/YZTTkEQKjtv4II+9l7/m8ohPSeIXwlaE22bBGRT9xQGj5+v9sA7j+V0D4wso7CoszbFXHCQfoeEnZewQ8BddoqFkCoY/1zd1BSiNlOrtBOCdbw8z09fmt2jn4bIIqEINqVaclMs1ZfjSyNcdZfiTo2lGqc6UuB7gnWnClHQgSq22qOIb/imS09OAgBkb60uKxpSVvHOVOR1byfoRZvlp3GAF6vCTrJUAmhTfAomATNSsyZ2tKcBuQ=="}',1
	union
	select 2,'{"Exponent":"AQAB","Modulus":"vbkbeXVIeK1JgMQpwfwmgWMCsMHAWIl0PdXSK62lQ0c/3iCt9AFduSNK3FZiv0kVc/Hx5vNBzFhB+BHah15shRqyFuO9zLGuBjB6bhcYkJ2/Z+yUI36PNgtBEofPGQzeIwRtdDRiBHs1EB0NFz/M45sdAi7Wm6VYUFSObx3J0EGt83rcSTMOU8U/lm/V3qT2NNlrxop0q3d4rGDgnBMi4OVopedT4V1uthVNuvTj8R09pynbCOwJDROvR+4VIrn03+th+lCgFWj3ms5xo8dCBK7SZsmaoSMU81zWAY73xzCgVK4vGHNxvBfOX7pgnhuzjKGSpFE5TIxVtAUdLyJGCQ=="}',1


	select * from [Certificate]

	SET IDENTITY_INSERT [Certificate] ON

	insert into [Certificate] (id,CertName, PublicKeyId, PrivateKeyId, Actual)
	select 99,'MokySigna',1,1,1
	union
	select 100,'TestForInvalidSigna',2,2,1
